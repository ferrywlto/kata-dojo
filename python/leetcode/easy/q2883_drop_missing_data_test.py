import pandas as pd


def dropMissingData(students: pd.DataFrame) -> pd.DataFrame:
    return students[students['name'].notnull()]


def test_dropMissingData():
    data = {
        'student_id': [32, 217, 779, 849],
        'name': ['Piper', None, 'Georgia', 'Willow'],
        'age': [5, 19, 20, 14]
    }
    students = pd.DataFrame(data)

    actual = dropMissingData(students)

    assert len(actual) == 3
    assert actual['name'].isnull().sum() == 0
