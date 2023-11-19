import { BaseWidgetModel, Column, WidgetType } from './baseWidgetModel.ts'
import { createCurrencyWidgetModel, CurrencyPair } from './currencyWidgetModel.ts'
import { createTextCardWidgetModel } from './textCardWidgetModel.ts'

const typeToCreateWidgetFuncMap = {
  [WidgetType.Currency]: (column: Column) => createCurrencyWidgetModel(CurrencyPair.UsdRub, column),
  [WidgetType.TextCard]: (column: Column) => createTextCardWidgetModel('Заголовок', 'Текст', column)
}

export function createWidget(type: WidgetType, column: Column): BaseWidgetModel {
  const createFunc = typeToCreateWidgetFuncMap[type]
  return createFunc(column)
}
