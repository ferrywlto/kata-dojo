import pandas as pd
import pandas.api.types as ptypes


def changeDatatype(students: pd.DataFrame) -> pd.DataFrame:
    students['grade'] = students['grade'].astype(int)
    return students


def test_changeDatatype():
    data = {
        'student_id': [1, 2],
        'name': ['Ava', 'Kate'],
        'age': [6, 15],
        'grade': [73.0, 87.0]
    }
    students = pd.DataFrame(data)

    actual = changeDatatype(students)

    assert ptypes.is_float_dtype(actual['grade']) == False
