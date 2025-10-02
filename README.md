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