import styled from 'styled-components'
import { WidgetGrid } from './ui/WidgetGrid.tsx'
import { createCtx } from '@reatom/framework'
import { reatomContext } from '@reatom/npm-react'
import { createGlobalStyle } from 'styled-components'

const GlobalStyles = createGlobalStyle`
  body {
    margin: 0;
  }
`

const AppContainer = styled.div`
  display: flex;
  min-height: 100vh;
`

export function App() {
  const ctx = createCtx()

  return (
    <reatomContext.Provider value={ctx}>
      <AppContainer>
        <GlobalStyles />
        <WidgetGrid />
      </AppContainer>
    </reatomContext.Provider>
  )
}
