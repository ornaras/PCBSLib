namespace PCBS
{
    public ref struct CommandKey
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
        public const int IS_ENABLED_TRANSFER_GS_CHARACTERS = 887001;
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
    }
}
