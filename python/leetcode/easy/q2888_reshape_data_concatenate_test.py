import pandas as pd

def concatenateTables(df1: pd.DataFrame, df2: pd.DataFrame) -> pd.DataFrame:
    return pd.concat([df1, df2])

def test_concatenateTables():
    data1 = {
        'student_id': [1, 2, 3, 4],
        'name': ['Mason', 'Ava', 'Taylor', 'Georgia'],
        'age': [8, 6, 15, 17]
    }
    df1 = pd.DataFrame(data1)
    
    data2 = {
        'student_id': [5, 6],
        'name': ['Leo', 'Alex'],
        'age': [7, 7]
    }
    df2 = pd.DataFrame(data2)
    
    # Call the function to test
    actual = concatenateTables(df1, df2)
    
    # Print the concatenated DataFrame
    print("Concatenated DataFrame:")
    print(actual)
    
    # Assertions to test the result
    assert len(actual) == 6  # Ensure the concatenated DataFrame has 6 rows
    assert 'student_id' in actual.columns
    assert 'name' in actual.columns
    assert 'age' in actual.columns
    
    # Check specific rows to ensure concatenation was done correctly
    assert actual.iloc[0]['student_id'] == 1
    assert actual.iloc[0]['name'] == 'Mason'
    assert actual.iloc[4]['student_id'] == 5
    assert actual.iloc[4]['name'] == 'Leo'