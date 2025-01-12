import pandas as pd

def selectData(students: pd.DataFrame) -> pd.DataFrame:
    row = students[students['student_id'] == 101]
    return row[['name', 'age']]

def test_selectData():
    data = {
        'student_id': [101, 53, 128, 3],
        'name': ['Ulysses', 'William', 'Henry', 'Henry'],
        'age': [13, 10, 6, 11]
    }
    students = pd.DataFrame(data)
    
    actual = selectData(students)
    
    assert len(actual) == 1
    assert actual.iloc[0]['name'] == 'Ulysses'
    assert actual.iloc[0]['age'] == 13