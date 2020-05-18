﻿using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebApiClientCore.Attributes
{
    /// <summary>
    /// 表示xml内容的模型结果
    /// </summary>
    public class XmlModelResultAttribute : ModelTypeResultAttribute
    {
        /// <summary>
        /// xml内容的强类型模型结果特性
        /// </summary>
        public XmlModelResultAttribute()
            : base(MediaTypeWithQualityHeaderValue.Parse(XmlContent.MediaType))
        {
        }

        /// <summary>
        /// 设置强类型模型结果值
        /// </summary>
        /// <param name="context">上下文</param>
        /// <returns></returns>
        public override async Task SetModelTypeResultAsync(ApiResponseContext context)
        {
            var resultType = context.ApiAction.Return.DataType.Type;
            context.Result = await context.XmlDeserializeAsync(resultType).ConfigureAwait(false);
        }
    }
}