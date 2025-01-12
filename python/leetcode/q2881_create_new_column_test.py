import pandas as pd


def createBonusColumn(employees: pd.DataFrame) -> pd.DataFrame:
    employees['bonus'] = employees['salary'] * 2
    return employees


def test():
    employees = {
        'name': ['Piper', 'Grace', 'Georgia', 'Willow', 'Finn', 'Thomas'],
        'salary': [4548, 28150, 1103, 6593, 74576, 24433]
    }
    df = createBonusColumn(pd.DataFrame(employees))
    assert len(df.columns) == 3
    assert df.columns.to_list()[2] == 'bonus'

    # Assert each bonus value is double the salary value
    for _, row in df.iterrows():
        assert row['bonus'] == row['salary'] * 2