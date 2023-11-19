import { getGuid } from '../utils'
import { atom, AtomMut } from '@reatom/framework'

export type WidgetId = number | string

export enum Column {
  First = 'First',
  Second = 'Second',
  Third = 'Third'
}

export enum WidgetType {
  Currency = 'Currency',
  TextCard = 'TextCard'
}

export type BaseWidgetModel = {
  id: Readonly<WidgetId>
  type: Readonly<WidgetType>
  column: AtomMut<Column>
}

export function createBaseWidgetModel(type: WidgetType, column: Column): BaseWidgetModel {
  return {
    id: getGuid(),
    type,
    column: atom(column)
  }
}
