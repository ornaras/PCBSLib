using static PCBS.UIGenerator;

namespace PCBS.UserControls
{
    public partial class Visual : CommandGroup
    {
        public Visual() : base(null,
            841013, 841014, 841001, 
            898005, 841008, 841009, 
            841002, 841006, 841007)
        {
            SuspendLayout();

            Controls.Add(CreateCheckBox("Активировать звуковой сигнал при старте", "841013", 33, 243));
            Controls.Add(CreateCheckBox("Активировать звуковой щелчок при нажатии на курок", "841014", 56, 302));
            Controls.Add(CreateCheckBox("Активировать звуковой сигнал успешного считывания", "841001", 79, 305));
            Controls.Add(CreateCheckBox("Активировать подсветку штрихкода", "898005", 102, 209));
            Controls.Add(CreateCheckBox("Активировать LED-сигнал успешного считывания", "841008", 125, 279));

            Controls.Add(CreateLabel("Громкость звуковых сигналов", 150, 163));
            Controls.Add(CreateLabel("Длительность сигнала успешного считывания кодов", 177, 277));
            Controls.Add(CreateLabel("Частота звуковых сигналов", 203, 150));
            Controls.Add(CreateLabel("Частота сигнала ошибки считывания кодов", 229, 230));

            Controls.Add(CreateNumberBox("841006", 159, 201, 120));
            Controls.Add(CreateNumberBox("841007", 240, 227, 120));

            Controls.Add(CreateComboBox("841009", 172, 147, 120, "Отключить", "Низкая", "Средняя", "Высокая"));
            Controls.Add(CreateComboBox("841002", 287, 174, 120, "По-умолчанию", "Короткий"));

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
