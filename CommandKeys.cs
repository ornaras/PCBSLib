namespace PCBS
{
    public static class CommandKey
    {
        #region Заводские настройки
        /// <summary>
        /// Вернуть сканер к заводским параметрам
        /// </summary>
        public const int RESET_SETTINGS = 800006;
        /// <summary>
        /// После ввода команды примените параметры, которые 
        /// необходимо сохранить в качестве настроек по умолчанию.
        /// </summary>
        public const int BEGIN_SETTINGS = 800010;
        /// <summary>
        /// По завершению настройки сканера сохраните пользовательские 
        /// настройки, чтобы примененные параметры не сбрасывались при 
        /// возврате сканера к заводским настройкам.
        /// </summary>
        public const int SAVE_SETTINGS = 800011;
        /// <summary>
        /// После ввода команды верните сканер к заводским параметрам, 
        /// чтобы удалить записанные ранее пользовательские настройки.
        /// </summary>
        public const int DELETE_SETTINGS = 800007;
        #endregion

        #region Об устройстве
        /// <summary>
        /// Серийный номер устройства
        /// </summary>
        public const int SERIAL_NUMBER = 811005;
        /// <summary>
        /// Версия прошивки
        /// </summary>
        public const int FIRMWARE_VERSION = 809004;
        #endregion

        #region Интерфейсы
        /// <summary>
        /// Интерфейс обмена данными:<br/>
        /// 0: RS232 <b>(Не поддерживает отправку команд)</b><br/>
        /// 124: USB-HID <b>(Для активации отправки команд нужно активировать <seealso href="IS_ENABLED_RECEIVE_COMMAND_IN_HID_MODE"/>)</b><br/>
        /// 131: USB-HID POS <b>(Не поддерживает отправку команд)</b><br/>
        /// 133: USB-COM
        /// </summary>
        public const int EXCHANGE_INTERFACE = 881001;
        /// <summary>
        /// Настройка возможности принятия конфигурационных команд 
        /// в режиме USB-HID(клавиатура) для настройки и обновления 
        /// прошивки сканера в режиме USB-HID.<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_RECEIVE_COMMAND_IN_HID_MODE = 942109;
        #endregion

        #region Разное
        /// <summary>
        /// В презентационном режиме сканер автоматически считывает 
        /// штрих-коды при попадании их в поле зрения сканера.<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 3 - Включить
        /// </summary>
        public const int IS_ENABLED_PRESENTATION_MODE = 861002;
        /// <summary>
        /// Длительность задержки чтения следующего кода в миллисекундах
        /// </summary>
        public const int DELAY_READING_FOLLOWING_CODE = 851006;
        /// <summary>
        /// Передача непечатных символов<br/><br/>
        /// Значения:<br/>
        /// 1 - Отключить<br/>
        /// 0 - Включить
        /// </summary>
        public const int IS_ENABLED_TRANSFER_GS_SYMBOLS = 887001;
        #endregion

        #region Звук и индикация
        /// <summary>
        /// Звуковой сигнал старте<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_START_BEEP = 841013;
        /// <summary>
        /// Звуковой щелчок при нажатии на курок<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_CLICK_BEEP = 841014;
        /// <summary>
        /// Звуковой сигнал успешного считывания<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_SUCCESS_BEEP = 841001;
        /// <summary>
        /// LED подсветка штрихкода<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_LIGHTING_LED = 898005;
        /// <summary>
        /// Громкость звуковых сигналов<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Низкая<br/>
        /// 2 - Средняя<br/>
        /// 3 - Высокая
        /// </summary>
        public const int VOLUME_SOUND = 841009;
        /// <summary>
        /// Частота звуковых сигналов<br/><br/>
        /// Значения:<br/>
        /// 1600 - Низкая<br/>
        /// 2400 - Средняя<br/>
        /// 4200 - Высокая
        /// </summary>
        public const int FREQUENCY_SOUND = 841006;
        /// <summary>
        /// Длительность сигнала успешного считывания кодов<br/><br/>
        /// Значения:<br/>
        /// 0 - Нормальный<br/>
        /// 1 - Короткий
        /// </summary>
        public const int DURATION_SUCCESS_BEEP = 841002;
        /// <summary>
        /// Частота сигнала ошибки считывания кодов<br/><br/>
        /// Значения:<br/>
        /// 250 - Низкая<br/>
        /// 3250 - Средняя<br/>
        /// 4200 - Высокая
        /// </summary>
        public const int FREQUENCY_ERROR_SOUND = 841007;
        /// <summary>
        /// LED сигнал успешного считывания <br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_SUCCESS_LED = 841008;
        #endregion

        #region Штрих-коды

        #region CODABAR
        /// <summary>
        /// Сброс всех настроек для CODABAR
        /// </summary>
        public const int RESET_CODABAR = 900000;
        /// <summary>
        /// Считывание CODABAR<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_CODABAR = 900003;
        /// <summary>
        /// Передача старт/стоп символов<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_BORDER_SYMBOLS_CODABAR = 900006;
        /// <summary>
        /// Режим работы с контрольным символом<br/><br/>
        /// Значения:<br/>
        /// 0 - Чтение без контрольного символа<br/>
        /// 1 - Чтение только с контрольными символами без 
        /// передачи контрольного символа<br/>
        /// 2 - Чтение только с контрольным символом и его передачей
        /// </summary>
        public const int READING_HASH_SYMBOL_CODABAR = 900001;
        /// <summary>
        /// Режим работы объедиения CODABAR<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить<br/>
        /// 2 - Требовать парный символ D
        /// </summary>
        public const int UNION_CODABAR = 900002;
        /// <summary>
        /// Минимальная длина пакета символов
        /// </summary>
        public const int MIN_LENGHT_CODABAR = 900005;
        /// <summary>
        /// Максимальную длина пакета символов
        /// </summary>
        public const int MAX_LENGHT_CODABAR = 900004;
        #endregion

        #region CODE39
        /// <summary>
        /// Сброс всех настроек для CODE39
        /// </summary>
        public const int RESET_CODE39 = 901000;
        /// <summary>
        /// Считывание CODE39<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_CODE39 = 901001;
        /// <summary>
        /// Передача старт/стоп символов<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_BORDER_SYMBOLS_CODE39 = 901009;
        /// <summary>
        /// Режим работы с контрольным символом<br/><br/>
        /// Значения:<br/>
        /// 0 - Чтение без контрольного символа<br/>
        /// 1 - Чтение только с контрольными символами без 
        /// передачи контрольного символа<br/>
        /// 2 - Чтение только с контрольным символом и его передачей
        /// </summary>
        public const int READING_HASH_SYMBOL_CODE39 = 901004;
        /// <summary>
        /// Режим работы объедиения CODE39<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int UNION_CODE39 = 901002;
        /// <summary>
        /// Минимальная длина пакета символов
        /// </summary>
        public const int MIN_LENGHT_CODE39 = 901008;
        /// <summary>
        /// Максимальную длина пакета символов
        /// </summary>
        public const int MAX_LENGHT_CODE39 = 901007;
        /// <summary>
        /// Считывание CODE32<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_CODE32 = 901005;
        /// <summary>
        /// FULL ASCII для CODE39<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_FULL_ASCII_CODE39 = 901003;
        #endregion

        #region Interleaved 2 of 5
        /// <summary>
        /// Сброс всех настроек для Interleaved 2 of 5
        /// </summary>
        public const int RESET_INTERLEAVED2OF5 = 902000;
        /// <summary>
        /// Считывание Interleaved 2 of 5<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_INTERLEAVED2OF5 = 902002;
        /// <summary>
        /// Режим работы с контрольным символом<br/><br/>
        /// Значения:<br/>
        /// 0 - Чтение без контрольного символа<br/>
        /// 1 - Чтение только с контрольными символами без 
        /// передачи контрольного символа<br/>
        /// 2 - Чтение только с контрольным символом и его передачей
        /// </summary>
        public const int READING_HASH_SYMBOL_INTERLEAVED2OF5 = 902001;
        /// <summary>
        /// Минимальная длина пакета символов
        /// </summary>
        public const int MIN_LENGHT_INTERLEAVED2OF5 = 902004;
        /// <summary>
        /// Максимальную длина пакета символов
        /// </summary>
        public const int MAX_LENGHT_INTERLEAVED2OF5 = 902003;
        #endregion

        #region NEC 2 of 5
        /// <summary>
        /// Сброс всех настроек для NEC 2 of 5
        /// </summary>
        public const int RESET_NEC2OF5 = 903000;
        /// <summary>
        /// Считывание NEC 2 of 5<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_NEC2OF5 = 903001;
        /// <summary>
        /// Режим работы с контрольным символом<br/><br/>
        /// Значения:<br/>
        /// 0 - Чтение без контрольного символа<br/>
        /// 1 - Чтение только с контрольными символами без 
        /// передачи контрольного символа<br/>
        /// 2 - Чтение только с контрольным символом и его передачей
        /// </summary>
        public const int READING_HASH_SYMBOL_NEC2OF5 = 903002;
        /// <summary>
        /// Минимальная длина пакета символов
        /// </summary>
        public const int MIN_LENGHT_NEC2OF5 = 903004;
        /// <summary>
        /// Максимальную длина пакета символов
        /// </summary>
        public const int MAX_LENGHT_NEC2OF5 = 903003;
        #endregion

        #region CODE93
        /// <summary>
        /// Сброс всех настроек для CODE93
        /// </summary>
        public const int RESET_CODE93 = 904000;
        /// <summary>
        /// Считывание CODE93<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_CODE93 = 904002;
        /// <summary>
        /// Минимальная длина пакета символов
        /// </summary>
        public const int MIN_LENGHT_CODE93 = 904004;
        /// <summary>
        /// Максимальную длина пакета символов
        /// </summary>
        public const int MAX_LENGHT_CODE93 = 904003;
        #endregion

        #region Straight 2 of 5 Industrial
        /// <summary>
        /// Сброс всех настроек для Straight 2 of 5 Industrial
        /// </summary>
        public const int RESET_STRAIGHT2OF5INDUSTRIAL = 905000;
        /// <summary>
        /// Считывание Straight 2 of 5 Industrial<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_STRAIGHT2OF5INDUSTRIAL = 905001;
        /// <summary>
        /// Минимальная длина пакета символов
        /// </summary>
        public const int MIN_LENGHT_STRAIGHT2OF5INDUSTRIAL = 905003;
        /// <summary>
        /// Максимальную длина пакета символов
        /// </summary>
        public const int MAX_LENGHT_STRAIGHT2OF5INDUSTRIAL = 905002;
        #endregion

        #region Straight 2 of 5 IATA
        /// <summary>
        /// Сброс всех настроек для Straight 2 of 5 IATA
        /// </summary>
        public const int RESET_STRAIGHT2OF5IATA = 906000;
        /// <summary>
        /// Считывание Straight 2 of 5 IATA<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_STRAIGHT2OF5IATA = 906001;
        /// <summary>
        /// Минимальная длина пакета символов
        /// </summary>
        public const int MIN_LENGHT_STRAIGHT2OF5IATA = 906003;
        /// <summary>
        /// Максимальную длина пакета символов
        /// </summary>
        public const int MAX_LENGHT_STRAIGHT2OF5IATA = 906002;
        #endregion

        #region Matrix 2 of 2
        /// <summary>
        /// Сброс всех настроек для Matrix 2 of 2
        /// </summary>
        public const int RESET_MATRIX2OF2 = 907000;
        /// <summary>
        /// Считывание Matrix 2 of 2<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_MATRIX2OF2 = 907001;
        /// <summary>
        /// Контрольным символом Matrix 2 of 2<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int READING_HASH_SYMBOL_MATRIX2OF2 = 907005;
        /// <summary>
        /// Минимальная длина пакета символов
        /// </summary>
        public const int MIN_LENGHT_MATRIX2OF2 = 907003;
        /// <summary>
        /// Максимальную длина пакета символов
        /// </summary>
        public const int MAX_LENGHT_MATRIX2OF2 = 907002;
        #endregion

        #region CODE11
        /// <summary>
        /// Сброс всех настроек для CODE11
        /// </summary>
        public const int RESET_CODE11 = 908000;
        /// <summary>
        /// Считывание CODE11<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_CODE11 = 908002;
        /// <summary>
        /// Минимальная длина пакета символов
        /// </summary>
        public const int MIN_LENGHT_CODE11 = 908004;
        /// <summary>
        /// Максимальную длина пакета символов
        /// </summary>
        public const int MAX_LENGHT_CODE11 = 908003;
        /// <summary>
        /// Количество контрольных символов<br/><br/>
        /// Значения:<br/>
        /// 0 - 1 символ<br/>
        /// 1 - 2 символа
        /// </summary>
        public const int READING_HASH_SYMBOL_CODE11 = 311028;
        #endregion

        #region CODE128
        /// <summary>
        /// Сброс всех настроек для CODE128
        /// </summary>
        public const int RESET_CODE128 = 909000;
        /// <summary>
        /// Считывание CODE128<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_CODE128 = 909001;
        /// <summary>
        /// Минимальная длина пакета символов
        /// </summary>
        public const int MIN_LENGHT_CODE128 = 909003;
        /// <summary>
        /// Максимальную длина пакета символов
        /// </summary>
        public const int MAX_LENGHT_CODE128 = 909002;
        /// <summary>
        /// Объедиение CODE128<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить<br/>
        /// </summary>
        public const int UNION_CODE128 = 902005;
        #endregion

        #region GS1-128
        /// <summary>
        /// Сброс всех настроек для GS1-128
        /// </summary>
        public const int RESET_GS128 = 910000;
        /// <summary>
        /// Считывание GS1-128<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_GS128 = 910001;
        /// <summary>
        /// Минимальная длина пакета символов
        /// </summary>
        public const int MIN_LENGHT_GS128 = 910003;
        /// <summary>
        /// Максимальную длина пакета символов
        /// </summary>
        public const int MAX_LENGHT_GS128 = 910002;
        #endregion

        #region Telepen
        /// <summary>
        /// Сброс всех настроек для Telepen
        /// </summary>
        public const int RESET_TELEPEN = 911000;
        /// <summary>
        /// Считывание Telepen<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_TELEPEN = 911001;
        /// <summary>
        /// Минимальная длина пакета символов
        /// </summary>
        public const int MIN_LENGHT_TELEPEN = 911003;
        /// <summary>
        /// Максимальную длина пакета символов
        /// </summary>
        public const int MAX_LENGHT_TELEPEN = 910002;
        #endregion

        #region UPC-A
        /// <summary>
        /// Сброс всех настроек для UPC-A
        /// </summary>
        public const int RESET_UPCA = 912000;
        /// <summary>
        /// Считывание UPC-A<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_UPCA = 912003;
        /// <summary>
        /// Разделитель между данными из UPC-A и доп. блоком<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_SPLITTER_UPCA = 912007;
        /// <summary>
        /// Контрольный символ<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_HASH_SYMBOL_UPCA = 912004;
        /// <summary>
        /// Передача 2-ух цифр из дополнительного блока<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_TRANSFER_ADDON2_UPCA = 912001;
        /// <summary>
        /// Передача 5 цифр из дополнительного блока<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_TRANSFER_ADDON5_UPCA = 912002;
        /// <summary>
        /// Режим сканирования UPC-A без доп. блока<br/><br/>
        /// Значения:<br/>
        /// 0 - Разрешить сканирование без доп.блоков<br/>
        /// 1 - Игнорировать коды без доп.блоков
        /// </summary>
        public const int IS_ENABLED_IGNORE_WOUT_ADDON_UPCA = 912006;
        /// <summary>
        /// Преобразование в EAN-13<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_CONVERT_TO_EAN13_UPCA = 912011;
        /// <summary>
        /// Передача преамбулы<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_TRANSFER_PREAMBULE_UPCA = 912005;
        #endregion

        #region UPC-E
        /// <summary>
        /// Сброс всех настроек для UPC-E0
        /// </summary>
        public const int RESET_UPCE0 = 914000;
        /// <summary>
        /// Считывание UPC-E0<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_UPCE0 = 914010;
        /// <summary>
        /// Считывание UPC-E1<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_UPCE1 = 914009;
        /// <summary>
        /// Разделитель между данными из UPC-E и доп. блоком<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_SPLITTER_UPCE = 914004;
        /// <summary>
        /// Контрольный символ<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_HASH_SYMBOL_UPCE = 914005;
        /// <summary>
        /// Передача 2-ух цифр из дополнительного блока<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_TRANSFER_ADDON2_UPCE = 914007;
        /// <summary>
        /// Передача 5 цифр из дополнительного блока<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_TRANSFER_ADDON5_UPCE = 914008;
        /// <summary>
        /// Режим сканирования UPC-E без доп. блока<br/><br/>
        /// Значения:<br/>
        /// 0 - Разрешить сканирование без доп.блоков<br/>
        /// 1 - Игнорировать коды без доп.блоков
        /// </summary>
        public const int IS_ENABLED_IGNORE_WOUT_ADDON_UPCE = 914003;
        /// <summary>
        /// Передача преамбулы<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_TRANSFER_PREAMBULE_UPCE = 914006;
        /// <summary>
        /// Расширение UPC-E до 12 символом<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_EXTENSION12_UPCE = 914002;
        #endregion

        #region EAN-13
        /// <summary>
        /// Сброс всех настроек для EAN-13
        /// </summary>
        public const int RESET_EAN13 = 915000;
        /// <summary>
        /// Считывание EAN-13<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_EAN13 = 915001;
        /// <summary>
        /// Разделитель между данными из EAN-13 и доп. блоком<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_SPLITTER_EAN13 = 915006;
        /// <summary>
        /// Контрольный символ<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_HASH_SYMBOL_EAN13 = 915002;
        /// <summary>
        /// Передача 2-ух цифр из дополнительного блока<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_TRANSFER_ADDON2_EAN13 = 915003;
        /// <summary>
        /// Передача 5 цифр из дополнительного блока<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_TRANSFER_ADDON5_EAN13 = 915004;
        /// <summary>
        /// Режим сканирования EAN-13 без доп. блока<br/><br/>
        /// Значения:<br/>
        /// 0 - Разрешить сканирование без доп.блоков<br/>
        /// 1 - Игнорировать коды без доп.блоков
        /// </summary>
        public const int IS_ENABLED_IGNORE_WOUT_ADDON_EAN13 = 915005;
        /// <summary>
        /// Преобразование в формат ISBN<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_CONVERT_TO_ISBN_EAN13 = 915007;
        #endregion

        #region EAN-8
        /// <summary>
        /// Сброс всех настроек для EAN-8
        /// </summary>
        public const int RESET_EAN8 = 916000;
        /// <summary>
        /// Считывание EAN-8<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_EAN8 = 916001;
        /// <summary>
        /// Разделитель между данными из EAN-8 и доп. блоком<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_SPLITTER_EAN8 = 916006;
        /// <summary>
        /// Контрольный символ<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_HASH_SYMBOL_EAN8 = 916002;
        /// <summary>
        /// Передача 2-ух цифр из дополнительного блока<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_TRANSFER_ADDON2_EAN8 = 916003;
        /// <summary>
        /// Передача 5 цифр из дополнительного блока<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_TRANSFER_ADDON5_EAN8 = 916004;
        /// <summary>
        /// Режим сканирования EAN-8 без доп. блока<br/><br/>
        /// Значения:<br/>
        /// 0 - Разрешить сканирование без доп.блоков<br/>
        /// 1 - Игнорировать коды без доп.блоков
        /// </summary>
        public const int IS_ENABLED_IGNORE_WOUT_ADDON_EAN8 = 916005;
        #endregion

        #region MSI
        /// <summary>
        /// Сброс всех настроек для MSI
        /// </summary>
        public const int RESET_MSI = 917000;
        /// <summary>
        /// Считывание MSI<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_MSI = 917001;
        /// <summary>
        /// Минимальная длина пакета символов
        /// </summary>
        public const int MIN_LENGHT_MSI = 917004;
        /// <summary>
        /// Максимальную длина пакета символов
        /// </summary>
        public const int MAX_LENGHT_MSI = 917003;
        /// <summary>
        /// Режим работы с контрольным символом<br/><br/>
        /// Значения:<br/>
        /// 0 - Подтверждать контрольный символ MOD 10 
        /// без передачи на хост<br/>
        /// 1 - Подтверждать контрольный символ MOD 10 
        /// и передать его на хост<br/>
        /// 6 - Отключить
        /// </summary>
        public const int IS_ENABLED_HASH_SYMBOL_MSI = 917002;
        #endregion

        #region GS1 DataBar Omnidirectional
        /// <summary>
        /// Сброс всех настроек для GS1 DataBar Omnidirectional
        /// </summary>
        public const int RESET_GS1O = 918000;
        /// <summary>
        /// Считывание GS1 DataBar Omnidirectional<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_GS1O = 918001;
        #endregion

        #region GS1 DataBar Limited
        /// <summary>
        /// Сброс всех настроек для GS1 DataBar Limited
        /// </summary>
        public const int RESET_GS1L = 919000;
        /// <summary>
        /// Считывание GS1 DataBar Limited<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_GS1L = 919001;
        #endregion

        #region GS1 DataBar Expanded
        /// <summary>
        /// Сброс всех настроек для GS1 DataBar Expanded
        /// </summary>
        public const int RESET_GS1E = 920000;
        /// <summary>
        /// Считывание GS1 DataBar Expanded<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_GS1E = 920001;
        /// <summary>
        /// Минимальная длина пакета символов
        /// </summary>
        public const int MIN_LENGHT_GS1E = 920003;
        /// <summary>
        /// Максимальную длина пакета символов
        /// </summary>
        public const int MAX_LENGHT_GS1E = 920002;
        #endregion

        #region PDF417
        /// <summary>
        /// Сброс всех настроек для PDF417
        /// </summary>
        public const int RESET_PDF417 = 924000;
        /// <summary>
        /// Считывание PDF417<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_PDF417 = 924001;
        /// <summary>
        /// Минимальная длина пакета символов
        /// </summary>
        public const int MIN_LENGHT_PDF417 = 924003;
        /// <summary>
        /// Максимальную длина пакета символов
        /// </summary>
        public const int MAX_LENGHT_PDF417 = 924002;
        #endregion

        #region QR
        /// <summary>
        /// Сброс всех настроек для QR
        /// </summary>
        public const int RESET_QR = 928000;
        /// <summary>
        /// Считывание QR<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_QR = 928001;
        /// <summary>
        /// Минимальная длина пакета символов
        /// </summary>
        public const int MIN_LENGHT_QR = 928003;
        /// <summary>
        /// Максимальную длина пакета символов
        /// </summary>
        public const int MAX_LENGHT_QR = 928002;
        #endregion

        #region Data Matrix
        /// <summary>
        /// Сброс всех настроек для Data Matrix
        /// </summary>
        public const int RESET_DATAMATRIX = 930000;
        /// <summary>
        /// Считывание Data Matrix<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_DATAMATRIX = 930001;
        /// <summary>
        /// Минимальная длина пакета символов
        /// </summary>
        public const int MIN_LENGHT_DATAMATRIX = 930003;
        /// <summary>
        /// Максимальную длина пакета символов
        /// </summary>
        public const int MAX_LENGHT_DATAMATRIX = 930002;
        #endregion

        #region Aztec Code
        /// <summary>
        /// Сброс всех настроек для Aztec Code
        /// </summary>
        public const int RESET_AZTECCODE = 931000;
        /// <summary>
        /// Считывание Aztec Code<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_AZTECCODE = 931001;
        /// <summary>
        /// Минимальная длина пакета символов
        /// </summary>
        public const int MIN_LENGHT_AZTECCODE = 931003;
        /// <summary>
        /// Максимальную длина пакета символов
        /// </summary>
        public const int MAX_LENGHT_AZTECCODE = 931002;
        #endregion

        #region China Post
        /// <summary>
        /// Сброс всех настроек для China Post
        /// </summary>
        public const int RESET_CHINAPOST = 936000;
        /// <summary>
        /// Считывание China Post<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_CHINAPOST = 936001;
        /// <summary>
        /// Минимальная длина пакета символов
        /// </summary>
        public const int MIN_LENGHT_CHINAPOST = 936003;
        /// <summary>
        /// Максимальную длина пакета символов
        /// </summary>
        public const int MAX_LENGHT_CHINAPOST = 936002;
        #endregion

        #region Korea Post
        /// <summary>
        /// Сброс всех настроек для Korea Post
        /// </summary>
        public const int RESET_KOREAPOST = 937000;
        /// <summary>
        /// Считывание Korea Post<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_KOREAPOST = 937001;
        /// <summary>
        /// Минимальная длина пакета символов
        /// </summary>
        public const int MIN_LENGHT_KOREAPOST = 937003;
        /// <summary>
        /// Максимальную длина пакета символов
        /// </summary>
        public const int MAX_LENGHT_KOREAPOST = 937002;
        /// <summary>
        /// Контрольный символ<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_HASH_SYMBOL_KOREAPOST = 937004;
        #endregion

        #region Han Xin Code
        /// <summary>
        /// Сброс всех настроек для Han Xin Code
        /// </summary>
        public const int RESET_HANXINCODE = 907000;
        /// <summary>
        /// Считывание Han Xin Code<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_HANXINCODE = 907001;
        /// <summary>
        /// Минимальная длина пакета символов
        /// </summary>
        public const int MIN_LENGHT_HANXINCODE = 907003;
        /// <summary>
        /// Максимальную длина пакета символов
        /// </summary>
        public const int MAX_LENGHT_HANXINCODE = 907002;
        #endregion

        #region Maxi Code
        /// <summary>
        /// Сброс всех настроек для Maxi Code
        /// </summary>
        public const int RESET_MAXICODE = 929000;
        /// <summary>
        /// Считывание Maxi Code<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_MAXICODE = 929001;
        /// <summary>
        /// Минимальная длина пакета символов
        /// </summary>
        public const int MIN_LENGHT_MAXICODE = 929003;
        /// <summary>
        /// Максимальную длина пакета символов
        /// </summary>
        public const int MAX_LENGHT_MAXICODE = 929002;
        #endregion

        #region MicroPDF
        /// <summary>
        /// Сброс всех настроек для MicroPDF
        /// </summary>
        public const int RESET_MICROPDF = 925000;
        /// <summary>
        /// Считывание MicroPDF<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_MICROPDF = 925001;
        /// <summary>
        /// Минимальная длина пакета символов
        /// </summary>
        public const int MIN_LENGHT_MICROPDF = 925003;
        /// <summary>
        /// Максимальную длина пакета символов
        /// </summary>
        public const int MAX_LENGHT_MICROPDF = 925002;
        #endregion

        #region Composites
        /// <summary>
        /// Сброс всех настроек для Composites
        /// </summary>
        public const int RESET_COMPOSITES = 926000;
        /// <summary>
        /// Считывание Composites<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_COMPOSITES = 926001;
        /// <summary>
        /// Минимальная длина пакета символов
        /// </summary>
        public const int MIN_LENGHT_COMPOSITES = 926004;
        /// <summary>
        /// Максимальную длина пакета символов
        /// </summary>
        public const int MAX_LENGHT_COMPOSITES = 926003;
        #endregion

        #region Codablock A
        /// <summary>
        /// Сброс всех настроек для Codablock A
        /// </summary>
        public const int RESET_CODABLOCKA = 922000;
        /// <summary>
        /// Считывание Codablock A<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_CODABLOCKA = 922001;
        /// <summary>
        /// Минимальная длина пакета символов
        /// </summary>
        public const int MIN_LENGHT_CODABLOCKA = 922003;
        /// <summary>
        /// Максимальную длина пакета символов
        /// </summary>
        public const int MAX_LENGHT_CODABLOCKA = 922002;
        #endregion

        #region Codablock F
        /// <summary>
        /// Сброс всех настроек для Codablock F
        /// </summary>
        public const int RESET_CODABLOCKF = 923000;
        /// <summary>
        /// Считывание Codablock F<br/><br/>
        /// Значения:<br/>
        /// 0 - Отключить<br/>
        /// 1 - Включить
        /// </summary>
        public const int IS_ENABLED_CODABLOCKF = 923001;
        /// <summary>
        /// Минимальная длина пакета символов
        /// </summary>
        public const int MIN_LENGHT_CODABLOCKF = 923003;
        /// <summary>
        /// Максимальную длина пакета символов
        /// </summary>
        public const int MAX_LENGHT_CODABLOCKF = 923002;
        #endregion

        #endregion
    }
}
