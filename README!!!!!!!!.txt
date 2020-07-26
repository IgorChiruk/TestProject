В приложении создана база данных с четырьмя таблицами:
-Day
-UserRecord
-ApplicationUser
-UserStatus

Кнопка LoadTestData считывает все фаилы из указаного каталога !!!заточена только под ваши тестовые данные.
Если указать любой другой каталог вылетит ошибка, обработку их сделать не успел. Но можно указывать
каталог с любым колличеством дней с записями. Логика чтения в классе LoadTestData.

При прочтении данных автоматически создаются пользователи(если их до этого не было), а также новые статусы,
хотя в тестовых данных все статусы "Finished" в задании сказано, что могут быть и другие.

UserRecord основная таблица которая в себе содержит все из тестовых данных.

Класс ApplicationViewModel клас представления который содержит в себе всю коллекцию представлений пользователя
(UserView).

UserView содержит поле Graph которое отвечает за отображение графика.

При нажатии на кнопку сохранить появляется диалоговое окно с выбором форматов по заданию, для сохранения
предусмотрены классы JsonSave,XMLSave,CSVSave(реализацию сделал бы лучше но не успел).

В конце реализации проекта возникла проблема - при выборе пользователя все колонки у кого ниже либо выше на 20%
среднее колличество шагов выделялось красным или зеленым соответственно, но при добавлении шапки в таблицу 
записи подсвечиваться перестали. Реализовать в полной мере не успел, но если из файла MainWindow.xaml удалить 
строки 
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
таблица будет без шапки но записи будут подсвечиваться.

на проект ушло около ~30 часов.
Буду рад комментариям к проекту и указанию на ошибки если возможно.