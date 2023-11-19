import { Column, TextCardWidgetModel } from '../../model'
import { useAtom } from '@reatom/npm-react'
import { Form, Input, Select } from 'antd'

type TextCardEditorProps = {
  textCardWidgetModel: TextCardWidgetModel
}

export function TextCardWidgetEditor(props: TextCardEditorProps) {
  const { textCardWidgetModel } = props

  const [title, setTitle] = useAtom(textCardWidgetModel.title)
  const [text, setText] = useAtom(textCardWidgetModel.text)
  const [column, setColumn] = useAtom(textCardWidgetModel.column)

  return (
    <Form layout="vertical">
      <Form.Item label="Колонка">
        <Select
          value={column}
          options={[
            { value: Column.First, label: 'Первая колонка' },
            { value: Column.Second, label: 'Вторая колонка' },
            { value: Column.Third, label: 'Третья колонка' }
          ]}
          onChange={setColumn}
        />
      </Form.Item>
      <Form.Item label="Заголовок">
        <Input value={title} onChange={(e) => setTitle(e.target.value)} />
      </Form.Item>
      <Form.Item label="Текст">
        <Input.TextArea value={text} onChange={(e) => setText(e.target.value)} />
      </Form.Item>
    </Form>
  )
}
