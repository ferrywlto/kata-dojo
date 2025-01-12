import pandas as pd
from typing import List


def createDataframe(student_data: List[List[int]]) -> pd.DataFrame:
    df = pd.DataFrame(student_data, columns=['student_id', 'age'])
    return df


def test_createDataframe():
    student_data = [
        [1, 15],
        [2, 11],
        [3, 11],
        [4, 20]
    ]
    df = createDataframe(student_data)
    assert len(df) == 4
    assert 'student_id' in df.columns
    assert 'age' in df.columns
    assert df.iloc[0]['student_id'] == 1
    assert df.iloc[0]['age'] == 15
    assert df.iloc[1]['student_id'] == 2
    assert df.iloc[1]['age'] == 11
    assert df.iloc[2]['student_id'] == 3
    assert df.iloc[2]['age'] == 11
    assert df.iloc[3]['student_id'] == 4
    assert df.iloc[3]['age'] == 20
