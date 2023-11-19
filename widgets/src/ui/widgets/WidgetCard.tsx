import { Button, Card } from 'antd'
import { SettingOutlined, DeleteOutlined } from '@ant-design/icons'
import { PropsWithChildren } from 'react'

type WidgetCardProps = {
  title: string
  onEditWidget?: () => void
  onRemove?: () => void
}

export function WidgetCard(props: PropsWithChildren<WidgetCardProps>) {
  const { title, onEditWidget, onRemove, children } = props

  const settingButton = (
    <>
      {onEditWidget && <Button type="text" onClick={onEditWidget} icon={<SettingOutlined />} />}
      {onRemove && <Button type="text" danger onClick={onRemove} icon={<DeleteOutlined />} />}
    </>
  )

  return (
    <Card bordered={false} title={title} extra={settingButton}>
      {children}
    </Card>
  )
}
