import { CurrencyPair } from '../../../model'
import axios from 'axios'
import { useEffect, useState } from 'react'

const PairToApiRoute = {
  [CurrencyPair.UsdRub]: 'USD',
  [CurrencyPair.EuroRub]: 'EUR'
}

export async function getCurrencyPairValue(pair: CurrencyPair) {
  const apiCode = PairToApiRoute[pair]
  const response = await axios.get(`https://open.er-api.com/v6/latest/${apiCode}`)

  return response.data?.rates?.['RUB'] as number
}

export function useCurrencyPairValue(currencyPair: CurrencyPair) {
  const [currencyPairValue, setCurrencyPairValue] = useState<number | undefined>()
  const [loading, setLoading] = useState(false)

  useEffect(() => {
    setLoading(true)
    getCurrencyPairValue(currencyPair)
      .then(setCurrencyPairValue)
      .finally(() => setLoading(false))
  }, [currencyPair])

  return { currencyPairValue, loading }
}
