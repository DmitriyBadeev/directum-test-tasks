import { action, atom, CtxSpy, reatomMap } from '@reatom/framework'
import { BaseWidgetModel, Column, WidgetId, WidgetType } from './baseWidgetModel.ts'
import { createWidget } from './widgetFactory.ts'
import { useAction, useAtom } from '@reatom/npm-react'

const widgetsAtom = reatomMap<WidgetId, BaseWidgetModel>()

const spyColumnWidgets = (ctx: CtxSpy, column: Column): BaseWidgetModel[] => {
  const widgets = ctx.spy(widgetsAtom)

  return Array.from(widgets.values()).filter((widget) => ctx.spy(widget.column) === column)
}

const firstColumnWidgetsAtom = atom((ctx) => spyColumnWidgets(ctx, Column.First))
const secondColumnWidgetsAtom = atom((ctx) => spyColumnWidgets(ctx, Column.Second))
const thirdColumnWidgetsAtom = atom((ctx) => spyColumnWidgets(ctx, Column.Third))

const addNewWidgetAction = action((ctx, type: WidgetType) => {
  const newWidget = createWidget(type, Column.First)
  widgetsAtom.set(ctx, newWidget.id, newWidget)
})

const removeWidgetAction = action((ctx, widgetId: WidgetId) => {
  widgetsAtom.delete(ctx, widgetId)
})

export function useWidgetGridModel() {
  const [firstColumnWidgets] = useAtom(firstColumnWidgetsAtom)
  const [secondColumnWidgets] = useAtom(secondColumnWidgetsAtom)
  const [thirdColumnWidgets] = useAtom(thirdColumnWidgetsAtom)

  const addNewWidget = useAction(addNewWidgetAction)
  const removeWidget = useAction(removeWidgetAction)

  return {
    firstColumnWidgets,
    secondColumnWidgets,
    thirdColumnWidgets,
    addNewWidget,
    removeWidget
  }
}
