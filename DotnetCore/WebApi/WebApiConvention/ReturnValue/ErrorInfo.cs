using System.ComponentModel;

namespace WebApiConvention.ReturnValue
{
    /// <summary>
    /// ��β������
    /// </summary>
    public enum ErrorCodeFirst
    {

        [Description("ҵ�����")]
        ҵ����� = 1,

        /// <summary>
        /// ����Ĳ���ֱ�ӷǷ�
        /// </summary>
        [Description("��������")]
        �������� = 2,

    }

    /// <summary>
    /// ĩβ������
    /// </summary>
    public enum ErrorCodeLast
    {
        δ���� = 0,

        /// <summary>
        /// �������ݵĹ����з��ֵĲ�����Ч
        /// <br>��:����ԭ����ɴ�������İ汾���ֶ��Ѿ���Ч</br>
        /// </summary>
        �����Ƿ� = 1,

        /// <summary>
        /// ���Ȳ�ѯ����µĲ�����
        /// <br>�����ֱ�Ӹ��µ�����������Ϊ0, �������ڲ����Ƿ�</br>
        /// <br>��: ����δ�ҵ�, </br>
        /// </summary>
        ������Դ�Ҳ��� = 2,

        /// <summary>
        /// Ȩ�޲���
        /// </summary>
        û�в���Ȩ�� = 3,

        /// <summary>
        /// δ��¼/��¼ƾ֤ʧЧ
        /// </summary>
        δ�ṩ���ƾ֤ = 4,
    }


    /// <summary>
    /// �������
    /// </summary>
    public record ErrorInfo
    {
        /*
         * ����: ��������λ��Ϊ������Ŀ��ͨ�ô�����
         * ��: 
         * ��λCode:
         * 1. ҵ�����
         * 
         * ĩλCode
         * 1. �����Ƿ�
         * 2. ������Դ�Ҳ���
         * 3. û�в���Ȩ��
         * 
         * ����: �û�������
         * 2xx0: {��������}{�����ֶκʹ�����Ϣ}{δ����}      
         * 1xx2: {ҵ�����}{������Ϣ��Ӧ�Ĵ�����}{������Դ�Ҳ���}
         * 
         * xx:
         * 1.�о�2λ��ֵ�㹻��
         * 2.��Ϊ�Ķ����01��ʼ, 00���Ա�ʾδ����Ĵ�����Ϣ/��AOP����ʹ��
         * 
         * ע:����û��ģ����Ϣ,����,�����������ظ�.���Ҫ���ظ�, ����ʹ��Controller+Action��Ϣ
         */
        /// <summary>
        /// ҵ�������
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        public string Message { get; set; }
 
    }

}