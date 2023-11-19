import { BaseWidgetModel, Column, createBaseWidgetModel, WidgetType } from './baseWidgetModel.ts'
import { atom, AtomMut } from '@reatom/framework'

export type TextCardWidgetModel = {
  title: AtomMut<string>
  text: AtomMut<string>
} & BaseWidgetModel

export function createTextCardWidgetModel(title: string, text: string, column: Column) {
  return {
    ...createBaseWidgetModel(WidgetType.TextCard, column),
    title: atom(title),
    text: atom(text)
  }
}

export function isTextCardWidgetModel(
  baseWidgetModel: BaseWidgetModel
): baseWidgetModel is TextCardWidgetModel {
  return baseWidgetModel.type === WidgetType.TextCard
}
