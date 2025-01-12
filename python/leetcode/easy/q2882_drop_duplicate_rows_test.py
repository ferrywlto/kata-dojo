import pandas as pd


def dropDuplicateEmails(customers: pd.DataFrame) -> pd.DataFrame:
    # drops rows that drop_duplicates() returns TRUE, see the test case below for details
    return customers.drop_duplicates(subset='email', keep='first')


def test_dropDuplicateEmails():
    duplicated_email = 'john@example.com'
    customers = [
        [1, 'Ella', 'emily@example.com'],
        [2, 'David', 'michael@example.com'],
        [3, 'Zachary', 'sarah@example.com'],
        [4, 'Alice', duplicated_email],
        [5, 'Finn', duplicated_email],
        [6, 'Violet', 'alice@example.com']
    ]
    df = dropDuplicateEmails(pd.DataFrame(
        customers, columns=['customer_id', 'name', 'email']))

    assert len(df['email']) == 5
    assert len(df[df['email'] == duplicated_email]) == 1
    # duplicated() has similar signature as drop_duplicates()
    # Mark all duplicates TRUE
    # duplicates_false = df.duplicated(subset='email', keep=False)
    # 0    False
    # 1    False
    # 2    False
    # 3     True <- Both marked true as keep set to false, don't keep any duplicates
    # 4     True <-
    # 5    False
    # dtype: bool

    # duplicates_first = df.duplicated(subset='email', keep='first')
    # Mark all duplicates TRUE except the first
    # 0    False
    # 1    False
    # 2    False
    # 3    False <- Marked false to keep because it is the first
    # 4     True
    # 5    False

    # duplicates_last = df.duplicated(subset='email', keep='last')
    # 0    False
    # 1    False
    # 2    False
    # 3     True
    # 4    False <- Marked false to keep because it is the last
    # 5    False