namespace PCBS
{
    public readonly struct PCBSResult
    {
        const string SUCCESS_MARK = "\u0006";

        public readonly string Command;
        public readonly bool IsSuccess;

        public int Code => int.Parse(Command.Substring(0, 6));
        public string Value => Command.Substring(6);
        public int ValueInt => int.Parse(Value);

        public PCBSResult(string response)
        {
            IsSuccess = response.EndsWith(SUCCESS_MARK);
            Command = response.Replace(SUCCESS_MARK, "");
        }
    }
}
