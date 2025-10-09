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


# CORS, SOP
    - Nguồn gốc (Origin) được định nghĩa bởi 3 thành phần:
        + Scheme (giao thức): http, https
        + Host (tên miền): example.com, localhost
        + Port (cổng): :80, :443, :5000

    - Same-Origine nếu cả 3 thành phần này giống nhau chúng được xem là cùng nguồn gốc.
    
    - Same-Origin Policy (SOP) là một tính năng bảo mật cực kỳ quan trọng được tích hợp sẵn trong tất cả các trình duyệt web hiện đại. Quy tắc cốt lõi của nó là: Một đoạn mã JavaScript chạy trên một trang web (ví dụ: https://my-page.com) chỉ được phép truy cập tài nguyên (dữ liệu, DOM) từ cùng một nguồn gốc (https://my-page.com). Nó bị ngăn chặn truy cập tài nguyên từ một nguồn gốc khác (ví dụ: https://api.another-site.com).

    - CORS (Cross-Origin Resource Sharing - Chia sẻ tài nguyên chéo nguồn gốc) là một cơ chế bảo mật, dựa trên các HTTP Header, cho phép một server chỉ định bất kỳ nguồn gốc (origin) nào khác (ngoài chính nó) được phép tải và tương tác với tài nguyên của nó.

    - Ví dụ: Trong kiến trúc web hiện đại, việc tách biệt Frontend và Backend là rất phổ biến:
        + Frontend: Một ứng dụng Single-Page Application (SPA) viết bằng React, Angular, Vue.js, chạy trên một tên miền như https://my-awesome-app.com.
        + Backend: Một Web API viết bằng ASP.NET Core, Node.js, Java, chạy trên một tên miền khác như https://api.my-awesome-app.com.
        + Khi ứng dụng Frontend (https://my-awesome-app.com) cần lấy dữ liệu, nó sẽ phải gọi đến API (https://api.my-awesome-app.com). Vì hai tên miền này khác nhau, đây là một yêu cầu chéo nguồn gốc (cross-origin).
        + Nếu không có CORS, trình duyệt sẽ áp dụng SOP và chặn yêu cầu này. Frontend sẽ không bao giờ nhận được dữ liệu, và ứng dụng không thể hoạt động.

    - CORS ra đời để giải quyết chính xác vấn đề này, cho phép các ứng dụng web hiện đại, phân tán có thể giao tiếp với nhau một cách an toàn và có kiểm soát.

    - Luồng CORS Tổng Quát:
        + Bước 1: JavaScript Khởi tạo Yêu cầu
            . Mã JavaScript trong ứng dụng của bạn (ví dụ: chạy trên https://my-frontend.com) thực hiện một yêu cầu mạng đến một API ở một nguồn gốc khác (ví dụ: https://api.my-backend.com).

        + Bước 2: Trình duyệt Can thiệp và Phân loại Yêu cầu
            . Trình duyệt chặn yêu cầu lại một chút và tự hỏi: "Yêu cầu này có 'đơn giản' hay 'phức tạp'?"
                "Đơn giản": Nếu là GET, POST với dữ liệu thông thường.
                "Phức tạp": Nếu là PUT, DELETE, hoặc có các thông tin "nhạy cảm" như Authorization header hoặc Content-Type: application/json.

            . Nhánh A: Nếu là Yêu cầu Đơn giản (Simple Request)
                . Bước A1: Trình duyệt Gửi Yêu cầu với Header Origin
                    Trình duyệt gửi thẳng yêu cầu đến server API. Nó tự động đính kèm một header Origin, ghi rõ nó đến từ đâu (GET đến /data với header Origin: https://my-frontend.com)
                . Bước A2: Server Kiểm tra và Phản hồi.
                    Server API nhận được yêu cầu.
                    Nó nhìn vào header Origin và kiểm tra trong (cấu hình CORS) của mình xem https://my-frontend.com có được phép vào không.
                    Nếu được phép: Server xử lý yêu cầu và trả về dữ liệu. Quan trọng nhất, nó đính kèm một header Access-Control-Allow-Origin trong phản hồi.
                    Server trả lời: Dữ liệu JSON kèm header Access-Control-Allow-Origin: https://my-frontend.com.
                    Nếu không được phép: Server có thể trả về lỗi, hoặc không đính kèm "Access-Control-Allow-Origin".
                . Bước A3: Trình duyệt Kiểm tra
                    Trình duyệt nhận được phản hồi.
                    Nó kiểm tra xem có Access-Control-Allow-Origin không và nó có khớp với địa chỉ của mình không.
                    Nếu khớp: Cuộc gọi thành công! Trình duyệt giao dữ liệu cho JavaScript.
                    Nếu không khớp: TRUY CẬP BỊ TỪ CHỐI! Trình duyệt hủy bỏ dữ liệu và báo lỗi CORS trên Console. JavaScript không nhận được gì cả.

            . Nhánh B: Nếu là Yêu cầu Phức tạp (Preflight Request)
                . Bước B1: Trình duyệt Gửi Yêu cầu "Thăm dò" (Preflight)
                    Trước khi gửi yêu cầu thật, trình duyệt gửi một yêu cầu "thăm dò" bằng phương thức OPTIONS.
                    Trình duyệt gửi: Yêu cầu OPTIONS với các header Origin, Access-Control-Request-Method, Access-Control-Request-Headers.
                . Bước B2: Server Phản hồi Yêu cầu "Thăm dò"
                    Server nhận yêu cầu OPTIONS và chỉ kiểm tra (cấu hình CORS) , không thưc hiện liền các yêu cầu http request.
                    Nếu được phép: Server trả lời "OK, ổn cả!" bằng cách gửi lại một danh sách các quyền hạn.
                    Nếu không được phép: Server sẽ im lặng hoặc trả lời không có quyền.
                . Bước B3: Trình duyệt Đánh giá và Quyết định
                    Trình duyệt nhận được phản hồi "thăm dò".
                    Nếu phản hồi cho phép: Tuyệt vời! Trình duyệt bây giờ mới gửi yêu cầu HTTP thật sự. Luồng tiếp theo sẽ diễn ra y hệt như Nhánh A (Simpler request) (từ bước A1 đến A3).
                    Nếu phản hồi không cho phép: KẾ HOẠCH BỊ HỦY BỎ! Yêu cầu HTTP thật sẽ không bao giờ được gửi. Trình duyệt báo lỗi CORS trên Console.


                
             





