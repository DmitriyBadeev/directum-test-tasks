import { Col, Row } from 'antd'
import { WidgetSettingPanel } from './WidgetSettingPanel.tsx'
import { BaseWidgetModel, useWidgetGridModel } from '../model'
import { Widget } from './Widget.tsx'
import { Layout } from 'antd'
import styled from 'styled-components'
import { useState } from 'react'
import { WidgetEditorDrawer } from './editors'

const WidgetGridContainer = styled.div`
  padding: 20px;
  display: flex;
  flex-direction: column;
  flex: auto;
`

const WidgetColumn = styled(Col)`
  display: flex;
  flex-direction: column;
  gap: 10px;
`

const WidgetLayout = styled(Layout)`
  padding: 10px;
`

export function WidgetGrid() {
  const { firstColumnWidgets, secondColumnWidgets, thirdColumnWidgets, removeWidget } =
    useWidgetGridModel()

  const [open, setOpen] = useState(false)
  const [editWidget, setEditWidget] = useState<BaseWidgetModel | null>(null)

  const openWidgetEditor = (widgetModel: BaseWidgetModel) => {
    setOpen(true)
    setEditWidget(widgetModel)
  }

  const removeWidgetHandler = (widgetModel: BaseWidgetModel) => {
    removeWidget(widgetModel.id)
  }

  const renderWidgetList = (widgets: BaseWidgetModel[]) =>
    widgets.map((widgetModel) => (
      <Widget
        key={widgetModel.id}
        widgetModel={widgetModel}
        onRemoveWidget={removeWidgetHandler}
        openWidgetEditor={openWidgetEditor}
      />
    ))

  return (
    <WidgetGridContainer>
      <WidgetSettingPanel />
      <WidgetLayout>
        <Row gutter={16} justify="center">
          <WidgetColumn span={8}>{renderWidgetList(firstColumnWidgets)}</WidgetColumn>
          <WidgetColumn span={8}>{renderWidgetList(secondColumnWidgets)}</WidgetColumn>
          <WidgetColumn span={8}>{renderWidgetList(thirdColumnWidgets)}</WidgetColumn>
        </Row>
      </WidgetLayout>
      {<WidgetEditorDrawer open={open} onClose={() => setOpen(false)} widgetModel={editWidget} />}
    </WidgetGridContainer>
  )
}
