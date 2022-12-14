using Microsoft.AspNetCore.Components;

namespace Fintech.Client.Shared
{
    public partial class ModelDialog : ComponentBase
    {
        [Parameter]
        public string Title { get; set; }
        [Parameter]
        public string Text { get; set; }
        [Parameter]
        public EventCallback<bool> OnClose { get; set; }
        [Parameter]
        public ModalDialogType DialogType { get; set; }

        private Task ModalCancel()
        {
            return OnClose.InvokeAsync(false);
        }
        private Task ModalOk()
        {
            return OnClose.InvokeAsync(true);
        }

        public enum ModalDialogType
        {
            Ok,
            OkCancel,
            DeleteCancel
        }
    }
}
