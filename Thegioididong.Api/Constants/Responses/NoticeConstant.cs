namespace Thegioididong.Api.Constants.Responses
{
    public class NoticeConstant
    {
        //Messages for CRUD operations
        public const string GetSuccessMessage = "Lấy thông tin thành công!";
        public const string CreateSuccessMessage = "Thêm mới thành công!";
        public const string EditSuccessMessage = "Cập nhật thành công!";
        public const string DeleteSuccessMessage = "Xóa thành công!";

        //Generic message headers
        public const string SuccessHeader = "Thành công!";
        public const string ErrorHeader = "Lỗi!";
        public const string InfoHeader = "Thông tin!";

        //Specific action messages
        public const string NoSelectionError = "Vui lòng chọn ít nhất một bản ghi để thực hiện hành động này!";
        public const string ProcessingRequest = "Đang xử lý yêu cầu của bạn.";
        public const string GenericErrorMessage = "Có lỗi xảy ra!";
        public const string GenericSuccessMessage = "Thực hiện thành công!";
        public const string ValidateEnumMessage = "Giá trị bạn đã nhập không hợp lệ!";
    }
}
