# Dpunity_C-_Asp.net
# Giải thích bài tập oop
    - Tính kế thừa: 
        + Tính kế thừa là cho phép lớp con thừa hưởng các thuộc tính và phương thức của lớp cha mà không cần định nghĩa lại.
        + Lớp con có thể thêm các thuộc tính hoặc phương thức mới hoặc ghi đè (override) các phương thức của lớp cha để thay đổi hành vi.
        + Ví dụ:
            . Các lớp con như Student và Teacher có thể kế thừa lớp cha Person và sử dụng các phương thức của lớp cha như(getName(), getAge(), setAge(), setName())
            . Và các lớp con Student và Teacher cũng có thể sửa(override) lại phương thức toString() của lớp cha Person để tự in thông tin của mình ra.

    - Tinh đóng gói:
        + Tính đóng gói nhằm bảo vệ dữ liệu bên trong một đối tượng bằng cách hạn chế truy cập trực tiếp vào các thuộc tính (fields) và chỉ cho phép tương tác thông qua các phương thức công khai (public methods), thường là getter và setter.
        + Sử dụng sửa đổi truy cập (Access Modifiers): private, protected, public, internal...
        + Ví dụ:
            . Lớp cha Person có các thuộc tính như (Name, age, role) cả 3 thuộc tính này điều dùng Access modifiers là private(chỉ cho phép truy cập trong cùng lớp) để đóng gói nó trong lớp Person.
            . Các lớp con như Teacher và Student không thể truy cập và sửa đổi trực tiếp vào các thuộc tính trên mà phải truy cập thông qua các phương thức getter() và setter() mà lớp cho cung cấp.
    
    - Tính đa hình:
        + Tính đa hình ám chỉ khả năng một phương thức hoặc toán tử có thể hoạt động khác nhau tùy thuộc vào ngữ cảnh hoặc đối tượng cụ thể.
        + Ví dụ:
            . Trong phương thức toString() của lớp cha Person có từ khóa virtual(từ khóa hỗ trợ giúp cho các lớp con có thể override lại phương thức này) và khi các lớp con Như Student và Teacher kế thừa lại lớp cha thì họ có thể ghi đè lên phương thức toString() kết hợp với dùng từ khóa override.

    - Tính trừu tượng: 
        + Tính trừu tượng là quá trình đơn giản hóa các chi tiết phức tạp của một hệ thống, chỉ tập trung vào những gì quan trọng và cần thiết cho người dùng, đồng thời ẩn đi các chi tiết triển khai.
        + Ví dụ: 
            . Trong project có 1 interface là StudentInterface trong interface có 1 phương thức trừu tượng là averageScore() không có thuộc tính hoặc logic triễn khai.
            . Lớp Student khi implement lại interface này thì đã triển khai phương thức averageScore().


    