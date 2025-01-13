import pandas as pd


def modifySalaryColumn(employees: pd.DataFrame) -> pd.DataFrame:
    employees['salary'] = employees['salary'] * 2
    return employees


def test_modifySalaryColumn():
    data = {
        'name': ['Jack', 'Piper', 'Mia', 'Ulysses'],
        'salary': [19666, 74754, 62509, 54866]        
    }
    old_employees = pd.DataFrame(data)
    employees = pd.DataFrame(data)
    
    actual = modifySalaryColumn(employees)
    
    assert len(actual) == 4
    
    for idx, row in actual.iterrows():
        assert row['salary'] == old_employees.iloc[idx]['salary'] * 2
