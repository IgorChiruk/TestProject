� ���������� ������� ���� ������ � �������� ���������:
-Day
-UserRecord
-ApplicationUser
-UserStatus

������ LoadTestData ��������� ��� ����� �� ��������� �������� !!!�������� ������ ��� ���� �������� ������.
���� ������� ����� ������ ������� ������� ������, ��������� �� ������� �� �����. �� ����� ���������
������� � ����� ������������ ���� � ��������. ������ ������ � ������ LoadTestData.

��� ��������� ������ ������������� ��������� ������������(���� �� �� ����� �� ����), � ����� ����� �������,
���� � �������� ������ ��� ������� "Finished" � ������� �������, ��� ����� ���� � ������.

UserRecord �������� ������� ������� � ���� �������� ��� �� �������� ������.

����� ApplicationViewModel ���� ������������� ������� �������� � ���� ��� ��������� ������������� ������������
(UserView).

UserView �������� ���� Graph ������� �������� �� ����������� �������.

��� ������� �� ������ ��������� ���������� ���������� ���� � ������� �������� �� �������, ��� ����������
������������� ������ JsonSave,XMLSave,CSVSave(���������� ������ �� ����� �� �� �����).

� ����� ���������� ������� �������� �������� - ��� ������ ������������ ��� ������� � ���� ���� ���� ���� �� 20%
������� ����������� ����� ���������� ������� ��� ������� ��������������, �� ��� ���������� ����� � ������� 
������ �������������� ���������. ����������� � ������ ���� �� �����, �� ���� �� ����� MainWindow.xaml ������� 
������ 
<ListView.View>
             <GridView>
                    <GridViewColumn DisplayMemberBinding="{Binding Path=Name}" Width="210">
                        <TextBlock FontSize="16" Width="210" Text="{Binding Name}">
                            <TextBlock.Background>
                                <SolidColorBrush Color="Red"/>
                            </TextBlock.Background>
                        </TextBlock>
                    </GridViewColumn>
                    <GridViewColumn DisplayMemberBinding="{Binding Path=AverageNumberOfSteps}" Width="80">Average</GridViewColumn>
                    <GridViewColumn DisplayMemberBinding="{Binding Path=BestNumberOfSteps}" Width="80">Best</GridViewColumn>
                    <GridViewColumn DisplayMemberBinding="{Binding Path=WorstNumberOfSteps}" Width="80">Worst</GridViewColumn>
                </GridView>
            </ListView.View>
������� ����� ��� ����� �� ������ ����� ��������������.

�� ������ ���� ����� ~30 �����.
���� ��� ������������ � ������� � �������� �� ������ ���� ��������.