import { BaseWidgetModel, isCurrencyWidgetModel, isTextCardWidgetModel } from '../model'
import { CurrencyWidget, TextCardWidget } from './widgets'

type WidgetProps = {
  widgetModel: BaseWidgetModel
} & BaseWidgetProps

export type BaseWidgetProps = {
  openWidgetEditor: (widget: BaseWidgetModel) => void
  onRemoveWidget: (widget: BaseWidgetModel) => void
}

export function Widget(props: WidgetProps) {
  const { widgetModel, ...baseProps } = props

  if (isCurrencyWidgetModel(widgetModel)) {
    return <CurrencyWidget currencyWidgetModel={widgetModel} {...baseProps} />
  }

  if (isTextCardWidgetModel(widgetModel)) {
    return <TextCardWidget textCardWidgetModel={widgetModel} {...baseProps} />
  }

  return <></>
}
