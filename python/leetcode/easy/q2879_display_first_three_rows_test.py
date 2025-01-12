import pandas as pd

def selectFirstRows(employees: pd.DataFrame) -> pd.DataFrame:
    return employees.head(3)

def test_selectFirstRows():
    data = {
        'employee_id': [3, 90, 9, 60, 49, 43],
        'name': ['Bob', 'Alice', 'Tatiana', 'Annabelle', 'Jonathan', 'Khaled'],
        'department': ['Operations', 'Sales', 'Engineering', 'InformationTechnology', 'HumanResources', 'Administration'],
        'salary': [48675, 11096, 33805, 37678, 23793, 40454]
    }
    employees = pd.DataFrame(data)
    
    actual = selectFirstRows(employees)
    
    assert len(actual) == 3
    # iloc = interger index location
    assert actual.iloc[0]['employee_id'] == 3
    assert actual.iloc[1]['employee_id'] == 90
    assert actual.iloc[2]['employee_id'] == 9
    