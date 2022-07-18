namespace Models.DockPanel
{
    public enum DockState
    {
        Unknown = 0,
        /// <summary>
        /// 悬浮
        /// </summary>
        Float = 1,
        /// <summary>
        /// 顶部窗体自动隐藏
        /// </summary>
        DockTopAutoHide = 2,
        /// <summary>
        /// 左停靠窗体自动隐藏
        /// </summary>
        DockLeftAutoHide = 3,
        /// <summary>
        /// 底部停靠窗体自动隐藏
        /// </summary>
        DockBottomAutoHide = 4,
        /// <summary>
        /// 右停靠窗体自动隐藏
        /// </summary>
        DockRightAutoHide = 5,
        /// <summary>
        /// 停靠窗体文档对象
        /// </summary>
        Document = 6,
        /// <summary>
        /// 顶部停靠
        /// </summary>
        DockTop = 7,
        /// <summary>
        /// 左停靠
        /// </summary>
        DockLeft = 8,
        /// <summary>
        /// 底部停靠
        /// </summary>
        DockBottom = 9,
        /// <summary>
        /// 右停靠
        /// </summary>
        DockRight = 10,
        Hidden = 11
}
}