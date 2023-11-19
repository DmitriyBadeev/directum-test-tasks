import { BaseWidgetModel, Column, createBaseWidgetModel, WidgetType } from './baseWidgetModel.ts'
import { atom, AtomMut } from '@reatom/framework'

export enum CurrencyPair {
  UsdRub = 'UsdRub',
  EuroRub = 'EuroRub'
}

export const CurrencyPairLabel = {
  [CurrencyPair.UsdRub]: 'Доллар/Рубль',
  [CurrencyPair.EuroRub]: 'Евро/Рубль'
}

export type CurrencyWidgetModel = {
  currencyPair: AtomMut<CurrencyPair>
} & BaseWidgetModel

export function createCurrencyWidgetModel(
  defaultPair: CurrencyPair,
  column: Column
): CurrencyWidgetModel {
  return {
    ...createBaseWidgetModel(WidgetType.Currency, column),
    currencyPair: atom(defaultPair)
  }
}

export function isCurrencyWidgetModel(
  baseWidgetModel: BaseWidgetModel
): baseWidgetModel is CurrencyWidgetModel {
  return baseWidgetModel.type === WidgetType.Currency
}
