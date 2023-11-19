import { CurrencyPairLabel, CurrencyWidgetModel } from '../../../model'
import { WidgetCard } from '../WidgetCard.tsx'
import { BaseWidgetProps } from '../../Widget.tsx'
import { useCurrencyPairValue } from './api.ts'
import { Spin, Statistic } from 'antd'
import { useAtom } from '@reatom/npm-react'

type CurrencyWidgetProps = {
  currencyWidgetModel: CurrencyWidgetModel
} & BaseWidgetProps

export function CurrencyWidget(props: CurrencyWidgetProps) {
  const { currencyWidgetModel, openWidgetEditor, onRemoveWidget } = props

  const [currencyPair] = useAtom(currencyWidgetModel.currencyPair)

  const { currencyPairValue, loading } = useCurrencyPairValue(currencyPair)

  const editHandler = () => openWidgetEditor(currencyWidgetModel)
  const removeHandler = () => onRemoveWidget(currencyWidgetModel)

  return (
    <Spin spinning={loading}>
      <WidgetCard title="Курс валют" onEditWidget={editHandler} onRemove={removeHandler}>
        <Statistic
          decimalSeparator=","
          title={CurrencyPairLabel[currencyPair]}
          precision={2}
          value={currencyPairValue}
        />
      </WidgetCard>
    </Spin>
  )
}
