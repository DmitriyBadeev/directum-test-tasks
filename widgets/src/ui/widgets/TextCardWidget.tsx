import { TextCardWidgetModel } from '../../model'
import { useAtom } from '@reatom/npm-react'
import { parseAtoms } from '@reatom/framework'
import { WidgetCard } from './WidgetCard.tsx'
import { BaseWidgetProps } from '../Widget.tsx'

type TextCardWidgetProps = {
  textCardWidgetModel: TextCardWidgetModel
} & BaseWidgetProps

export function TextCardWidget(props: TextCardWidgetProps) {
  const { textCardWidgetModel, openWidgetEditor, onRemoveWidget } = props

  const [{ title, text }] = useAtom((ctx) => parseAtoms(ctx, textCardWidgetModel))

  const settingHandler = () => openWidgetEditor(textCardWidgetModel)
  const removeHandler = () => onRemoveWidget(textCardWidgetModel)

  return (
    <WidgetCard title={title} onEditWidget={settingHandler} onRemove={removeHandler}>
      {text}
    </WidgetCard>
  )
}
