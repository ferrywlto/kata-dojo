import pandas as pd


def meltTable(report: pd.DataFrame) -> pd.DataFrame:
    return pd.melt(report, id_vars=['product'], var_name='quarter', value_name='sales')
# id_vars: Columns to use as identifier variables. These columns will remain as they are.
# value_vars: Columns to unpivot. If not specified, all columns not in id_vars will be used.
# var_name: Name to use for the variable column. This column will contain the names of the original columns that were unpivoted.
# value_name: Name to use for the value column. This column will contain the values from the original columns that were unpivoted.


def test_meltTable():
    data = {
        'product': ['Umbrella', 'SleepingBag'],
        'quarter_1': [417, 800],
        'quarter_2': [224, 936],
        'quarter_3': [379, 93],
        'quarter_4': [611, 875]
    }
    report = pd.DataFrame(data)

    melted_report = meltTable(report)

    assert 'product' in melted_report.columns
    assert 'quarter' in melted_report.columns
    assert 'sales' in melted_report.columns
    assert len(melted_report) == 8  # 2 products * 4 quarters = 8 rows
    assert melted_report.iloc[0]['product'] == 'Umbrella'
    assert melted_report.iloc[0]['quarter'] == 'quarter_1'
    assert melted_report.iloc[0]['sales'] == 417
    assert melted_report.iloc[1]['product'] == 'SleepingBag'
    assert melted_report.iloc[1]['quarter'] == 'quarter_1'
    assert melted_report.iloc[1]['sales'] == 800
