import { useWidgetGridModel, WidgetType } from '../model'
import { Button, Dropdown, Flex, MenuProps, Space } from 'antd'
import { DownOutlined } from '@ant-design/icons'
import styled from 'styled-components'

const PanelContainer = styled(Flex)`
  padding: 15px;
  border-radius: 5px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  margin-bottom: 20px;
`

export function WidgetSettingPanel() {
  const { addNewWidget } = useWidgetGridModel()

  const items: MenuProps['items'] = [
    {
      label: 'Курс валют',
      key: WidgetType.Currency
    },
    {
      label: 'Карточка',
      key: WidgetType.TextCard
    }
  ]

  const createNewWidgetHandler: MenuProps['onClick'] = (event) => {
    const widgetType = event.key as WidgetType
    addNewWidget(widgetType)
  }

  const menuProps = {
    items,
    onClick: createNewWidgetHandler
  }

  return (
    <PanelContainer>
      <Dropdown menu={menuProps}>
        <Button>
          <Space>
            Добавить виджет
            <DownOutlined />
          </Space>
        </Button>
      </Dropdown>
    </PanelContainer>
  )
}
