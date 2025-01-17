using System.Text;

namespace Mooege.Net.GS.Message.Fields
{
    public class GameSyncedData
    {
        public bool Field0;
        public int Field1;
        public int Field2;
        public int Field3;
        public int Field4;
        public int Field5;
        // MaxLength = 2
        public int[] Field6;
        // MaxLength = 2
        public int[] Field7;

        public void Parse(GameBitBuffer buffer)
        {
            Field0 = buffer.ReadBool();
            Field1 = buffer.ReadInt(32);
            Field2 = buffer.ReadInt(32);
            Field3 = buffer.ReadInt(32);
            Field4 = buffer.ReadInt(32);
            Field5 = buffer.ReadInt(32);
            Field6 = new int[2];
            for (int i = 0; i < Field6.Length; i++) Field6[i] = buffer.ReadInt(32);
            Field7 = new int[2];
            for (int i = 0; i < Field7.Length; i++) Field7[i] = buffer.ReadInt(32);
        }

        public void Encode(GameBitBuffer buffer)
        {
            buffer.WriteBool(Field0);
            buffer.WriteInt(32, Field1);
            buffer.WriteInt(32, Field2);
            buffer.WriteInt(32, Field3);
            buffer.WriteInt(32, Field4);
            buffer.WriteInt(32, Field5);
            for (int i = 0; i < Field6.Length; i++) buffer.WriteInt(32, Field6[i]);
            for (int i = 0; i < Field7.Length; i++) buffer.WriteInt(32, Field7[i]);
        }

        public void AsText(StringBuilder b, int pad)
        {
            b.Append(' ', pad);
            b.AppendLine("GameSyncedData:");
            b.Append(' ', pad++);
            b.AppendLine("{");
            b.Append(' ', pad);
            b.AppendLine("Field0: " + (Field0 ? "true" : "false"));
            b.Append(' ', pad);
            b.AppendLine("Field1: 0x" + Field1.ToString("X8") + " (" + Field1 + ")");
            b.Append(' ', pad);
            b.AppendLine("Field2: 0x" + Field2.ToString("X8") + " (" + Field2 + ")");
            b.Append(' ', pad);
            b.AppendLine("Field3: 0x" + Field3.ToString("X8") + " (" + Field3 + ")");
            b.Append(' ', pad);
            b.AppendLine("Field4: 0x" + Field4.ToString("X8") + " (" + Field4 + ")");
            b.Append(' ', pad);
            b.AppendLine("Field5: 0x" + Field5.ToString("X8") + " (" + Field5 + ")");
            b.Append(' ', pad);
            b.AppendLine("Field6:");
            b.Append(' ', pad);
            b.AppendLine("{");
            for (int i = 0; i < Field6.Length;)
            {
                b.Append(' ', pad + 1);
                for (int j = 0; j < 8 && i < Field6.Length; j++, i++)
                {
                    b.Append("0x" + Field6[i].ToString("X8") + ", ");
                }
                b.AppendLine();
            }
            b.Append(' ', pad);
            b.AppendLine("}");
            b.AppendLine();
            b.Append(' ', pad);
            b.AppendLine("Field7:");
            b.Append(' ', pad);
            b.AppendLine("{");
            for (int i = 0; i < Field7.Length;)
            {
                b.Append(' ', pad + 1);
                for (int j = 0; j < 8 && i < Field7.Length; j++, i++)
                {
                    b.Append("0x" + Field7[i].ToString("X8") + ", ");
                }
                b.AppendLine();
            }
            b.Append(' ', pad);
            b.AppendLine("}");
            b.AppendLine();
            b.Append(' ', --pad);
            b.AppendLine("}");
        }


    }
}