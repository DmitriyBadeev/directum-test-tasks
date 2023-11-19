import { Column, CurrencyPair, CurrencyPairLabel, CurrencyWidgetModel } from '../../model'
import { Form, Select } from 'antd'
import { useAtom } from '@reatom/npm-react'

type CurrencyEditorProps = {
  currencyWidgetModel: CurrencyWidgetModel
}

export function CurrencyWidgetEditor(props: CurrencyEditorProps) {
  const { currencyWidgetModel } = props

  const [column, setColumn] = useAtom(currencyWidgetModel.column)
  const [currencyPair, setCurrencyPair] = useAtom(currencyWidgetModel.currencyPair)

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
      <Form.Item label="Пара">
        <Select
          value={currencyPair}
          options={[
            { value: CurrencyPair.UsdRub, label: CurrencyPairLabel[CurrencyPair.UsdRub] },
            { value: CurrencyPair.EuroRub, label: CurrencyPairLabel[CurrencyPair.EuroRub] }
          ]}
          onChange={setCurrencyPair}
        />
      </Form.Item>
    </Form>
  )
}
