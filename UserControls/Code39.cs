using static PCBS.UIGenerator;

namespace PCBS.UserControls
{
    public partial class Code39 : CommandGroup
    {
        public Code39(): base(
            commandReset: 901000,
            901001, 901008, 901007,
            901002, 901003, 901004,
            901005, 901009)
        {
            SuspendLayout();

            Controls.Add(CreateCheckBox("Активировать считывание CODE39", "901001", 33, 205));
            Controls.Add(CreateCheckBox("Активировать считывание CODE32", "901005", 56, 205));
            Controls.Add(CreateCheckBox("Активировать объедиение CODE39", "901002", 79, 189));
            Controls.Add(CreateCheckBox("Активировать передачу старт/стоп-символов для CODE39", "901009", 102, 308));
            Controls.Add(CreateCheckBox("Активировать FULL ASCII CODE39", "901003", 125, 184));

            Controls.Add(CreateLabel("Режим работы с контрольным символом CODE39", 151, 263));
            Controls.Add(CreateLabel("Минимальная длина пакета символов CODE39", 177, 247));
            Controls.Add(CreateLabel("Максимальная длина пакета символов CODE39", 203, 253));

            Controls.Add(CreateNumberBox("901008", 256, 175, 120));
            Controls.Add(CreateNumberBox("901007", 262, 201, 120));

            Controls.Add(CreateComboBox("901004", 272, 148, 325,
                "Чтение без контрольного символа",
                "Чтение только с контрольными символами без его передачи",
                "Чтение только с контрольным символом и его передачей"));

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
