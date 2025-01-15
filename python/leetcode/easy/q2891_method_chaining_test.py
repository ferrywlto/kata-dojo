import pandas as pd
from pandas.testing import assert_frame_equal


def findHeavyAnimals(animals: pd.DataFrame) -> pd.DataFrame:
    return pd.DataFrame(animals[animals['weight'] > 100]
                        .sort_values(by='weight', ascending=False)['name'])


def test_findHeavyAnimals():
    data = {
        'name': ['Tatiana', 'Khaled', 'Alex', 'Jonathan', 'Stefan', 'Tommy'],
        'species': ['Snake', 'Giraffe', 'Leopard', 'Monkey', 'Bear', 'Panda'],
        'age': [98, 50, 6, 45, 100, 26],
        'weight': [464, 41, 328, 463, 50, 349]
    }
    animals = pd.DataFrame(data)
    expected = pd.DataFrame({'name': ['Tatiana', 'Jonathan', 'Tommy', 'Alex']})

    actual = findHeavyAnimals(animals)
    actual = actual.reset_index(drop=True)

    assert len(actual) == 4
    # or use assert expected.equals(actual)
    assert_frame_equal(expected, actual)
