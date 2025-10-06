# Dpunity_C-_Asp.net
# Jwt Authentication and Authorization
    - Jwt: Là một tiêu chuẩn mở, định nghĩa một phương thức nhỏ gọn và khép kín (compact and self-contained) để truyền tải thông tin an toàn giữa các bên dưới dạng một đối tượng JSON. Thông tin này có thể được xác minh và tin cậy vì nó đã được ký điện tử (digitally signed).
        + Header: Một đối tượng JSON chứa metadata về token.
            . alg (Algorithm): Thuật toán ký được sử dụng, ví dụ HS256 (HMAC-SHA256) hoặc RS256 (RSA-SHA256).
            . typ (Type): Loại token, luôn là "JWT".
        + Payload: Một đối tượng JSON chứa các Claims, chứa thông tin thực tế mà người dùng muốn truyền đi
            . Registered Claims: Các claim được định nghĩa trước (ví dụ: iss - issuer, sub - subject, aud - audience, exp - expiration time).
            . Public Claims: Các claim được định nghĩa bởi người dùng JWT nhưng cần được đăng ký để tránh xung đột.
            . Private Claims: Các claim tùy chỉnh được định nghĩa riêng cho ứng dụng (ví dụ: role, permissions)
        + Signature: Chữ ký điện tử được tạo ra để xác minh tính toàn vẹn và nguồn gốc của token.
            . Nó được tính toán dựa trên Header đã mã hóa, Payload đã mã hóa, một khóa bí mật (secret key), và thuật toán được chỉ định trong alg.
    - Authentication là quá trình xác định và xác minh danh tính của một thực thể (user, service, device). Mục tiêu của nó là trả lời câu hỏi: "Thực thể này có phải là thực thể mà nó tuyên bố không?".
    - Authorization là quá trình xác định xem một thực thể đã được xác thực (authenticated entity) có được cấp quyền để thực hiện một hành động cụ thể hoặc truy cập một tài nguyên cụ thể hay không. Quá trình này diễn ra sau khi quá trình authentication đã thành công và nó trả lời câu hỏi: "Thực thể này có được phép làm điều này không?".



    
# MiddleWare
    - Middleware là các thành phần phần mềm được sắp xếp thành một "đường ống" (pipeline) để xử lý các yêu cầu (request) và phản hồi (response) trong ứng dụng ASP.NET Core. Mỗi thành phần có thể thực hiện các thao tác trước và sau khi thành phần tiếp theo trong đường ống được gọi.
# Authentication
    - Đây là một khái niệm bảo mật. Mục tiêu duy nhất của nó là xác minh danh tính của người dùng hoặc hệ thống đang gửi request.
    - Sau khi Authentication thành công, nó sẽ tạo ra một đối tượng danh tính (gọi là ClaimsPrincipal) và gắn nó vào request hiện tại (HttpContext.User). Đối tượng này chứa thông tin về người dùng như ID, username, roles (vai trò), và các claims khác. Nếu thất bại, nó có thể từ chối request (trả về lỗi 401 Unauthorized).
    - Mối quan hệ với Middleware: Trong ASP.NET Core, khái niệm Authentication được hiện thực hóa bằng một middleware cụ thể: app.UseAuthentication(). Middleware này sẽ thực hiện các công việc kiểm tra token, cookie...
# Authorization
    - Đây cũng là một khái niệm bảo mật. Sau khi đã biết người dùng là ai (nhờ Authentication), mục tiêu của nó là kiểm tra xem người dùng đó có quyền thực hiện hành động họ đang yêu cầu hay không
    - Authorization luôn luôn phải đi sau Authentication không thể biết một người được làm gì nếu chưa biết họ là ai.
    - Mối quan hệ với Middleware: Khái niệm Authorization cũng được hiện thực hóa bằng một middleware cụ thể: app.UseAuthorization(). Middleware này sẽ lấy danh tính từ HttpContext.User (do Authentication middleware tạo ra) và đối chiếu với các quy tắc được định nghĩa cho endpoint đó (ví dụ: attribute [Authorize(Roles = "Admin")]). Nếu không đủ quyền, nó sẽ từ chối request (trả về lỗi 403 Forbidden).


