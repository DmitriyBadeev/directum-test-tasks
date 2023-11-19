import { Drawer } from 'antd'
import { BaseWidgetModel } from '../../model'
import { WidgetEditor } from './WidgetEditor.tsx'

type WidgetEditorProps = {
  widgetModel: BaseWidgetModel | null
  open: boolean
  onClose: () => void
}

export function WidgetEditorDrawer(props: WidgetEditorProps) {
  const { widgetModel, open, onClose } = props

  return (
    <Drawer title="Редактирование виджета" destroyOnClose open={open} onClose={onClose}>
      {widgetModel && <WidgetEditor widgetModel={widgetModel} />}
    </Drawer>
  )
}
