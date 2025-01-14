import pandas as pd

def fillMissingValues(products: pd.DataFrame) -> pd.DataFrame:
    products['quantity'] = products['quantity'].fillna(0)
    return products

def test_fillMissingValues():
    data = {
        'name': ['Wristwatch', 'WirelessEarbuds', 'GolfClubs', 'Printer'],
        'quantity': [None, None, 779, 849],
        'price': [135, 821, 9319, 3051]
    }
    products = pd.DataFrame(data)
    
    actual = fillMissingValues(products)
    
    assert actual['quantity'].isnull().sum() == 0
    assert actual['quantity'].iloc[0] == 0
    assert actual['quantity'].iloc[1] == 0