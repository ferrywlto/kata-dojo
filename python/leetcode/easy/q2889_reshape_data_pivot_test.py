import pandas as pd


def pivotTable(weather: pd.DataFrame) -> pd.DataFrame:
    return weather.pivot(index='month', columns='city', values='temperature')


def test_pivotTable():
    data = {
        'city': ['Jacksonville', 'Jacksonville', 'Jacksonville', 'Jacksonville', 'Jacksonville',
                 'ElPaso', 'ElPaso', 'ElPaso', 'ElPaso', 'ElPaso'],
        'month': ['January', 'February', 'March', 'April', 'May',
                  'January', 'February', 'March', 'April', 'May'],
        'temperature': [13, 23, 38, 5, 34, 20, 6, 26, 2, 43]
    }
    weather = pd.DataFrame(data)

    pivoted_weather = pivotTable(weather)

    assert 'Jacksonville' in pivoted_weather.columns
    assert 'ElPaso' in pivoted_weather.columns
    assert 'January' in pivoted_weather.index
    assert pivoted_weather.loc['January', 'Jacksonville'] == 13
    assert pivoted_weather.loc['May', 'ElPaso'] == 43
