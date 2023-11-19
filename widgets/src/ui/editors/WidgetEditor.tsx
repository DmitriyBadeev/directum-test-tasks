import { BaseWidgetModel, isCurrencyWidgetModel, isTextCardWidgetModel } from '../../model'
import { CurrencyWidgetEditor } from './CurrencyWidgetEditor.tsx'
import { TextCardWidgetEditor } from './TextCardWidgetEditor.tsx'

type WidgetEditorProps = {
  widgetModel: BaseWidgetModel
}

export function WidgetEditor(props: WidgetEditorProps) {
  const { widgetModel } = props

  if (isCurrencyWidgetModel(widgetModel)) {
    return <CurrencyWidgetEditor currencyWidgetModel={widgetModel} />
  }

  if (isTextCardWidgetModel(widgetModel)) {
    return <TextCardWidgetEditor textCardWidgetModel={widgetModel} />
  }

  return <></>
}
