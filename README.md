# 🚀 Space Shooter Game - Gamedev Midterm Project

Một trò chơi bắn súng không gian 2D được phát triển bằng Unity, nơi người chơi điều khiển một phi thuyền để tiêu diệt thiên thạch và sinh tồn càng lâu càng tốt.

## 📋 Mô tả

Game là một space shooter 2D với cơ chế điều khiển đơn giản nhưng đầy thử thách. Người chơi phải né tránh và bắn hạ các thiên thạch bay về phía mình, với hệ thống mạng sống giới hạn và hiệu ứng âm thanh sống động.

## 🎮 Tính năng

### Điều khiển nhân vật
- **Di chuyển**: Giữ chuột trái để phi thuyền di chuyển về phía con trỏ chuột
- **Xoay hướng**: Phi thuyền tự động quay theo vị trí con trỏ chuột
- **Bắn đạn**: Nhấn phím `W` để bắn (có cooldown 0.5s giữa mỗi lần bắn)

### Hệ thống gameplay
- **Hệ thống máu**: Người chơi có số mạng giới hạn, hiển thị bằng UI trái tim
- **Vô địch tạm thời**: Sau khi bị đánh, người chơi có thời gian bất tử ngắn (invincibility frames)
- **Thiên thạch**: Xuất hiện với kích thước ngẫu nhiên và tự động bay về phía người chơi
- **Hiệu ứng nổ**: Animation nổ khi thiên thạch bị phá hủy hoặc va chạm
- **Âm thanh**: Hiệu ứng âm thanh khi bắn đạn

### Cơ chế game
- Thiên thạch tự động tìm đường về phía người chơi
- Đạn bay theo hướng phi thuyền đang quay
- Thiên thạch tự động biến mất khi ra khỏi màn hình
- Game over khi hết mạng

## 🛠️ Công nghệ sử dụng

- **Engine**: Unity
- **Ngôn ngữ**: C# (64.4%)
- **Shader**: ShaderLab (29.5%), HLSL (6.1%)
- **TextMesh Pro**: Để render text UI chất lượng cao

## 📁 Cấu trúc dự án

```
Assets/
├── PlayerControll.cs          # Điều khiển di chuyển, xoay và bắn của người chơi
├── PlayerHealth.cs            # Quản lý máu và hệ thống mạng sống
├── Asteroid_Small.cs          # Logic của thiên thạch (di chuyển, va chạm, nổ)
├── TextMesh Pro/              # Thư viện UI TextMesh Pro
└── [Other game assets]
```

## 🎯 Các class chính

### PlayerControll.cs
Quản lý toàn bộ hành động của người chơi:
- Xoay phi thuyền theo chuột
- Di chuyển khi giữ chuột trái
- Bắn đạn với fire rate control
- Phát âm thanh khi bắn

### PlayerHealth.cs
Quản lý hệ thống sinh tồn:
- Theo dõi số mạng hiện tại
- Xử lý va chạm với enemy
- Hiệu ứng invincibility sau khi bị đánh
- Cập nhật UI hiển thị trái tim
- Trigger Game Over

### Asteroid_Small.cs
Quản lý hành vi của thiên thạch:
- Tự động tìm và di chuyển về phía người chơi
- Kích thước ngẫu nhiên
- Xử lý va chạm với đạn
- Animation nổ khi bị phá hủy
- Auto-destroy khi ra khỏi bounds

## 🚀 Cài đặt và chạy

1. Clone repository:
```bash
git clone https://github.com/it2kvku/gamedev-midterm.git
```

2. Mở project trong Unity (khuyến nghị Unity 2021.3 LTS trở lên)

3. Mở scene chính và nhấn Play để chơi

## 🎮 Hướng dẫn chơi

1. **Mục tiêu**: Tiêu diệt càng nhiều thiên thạch càng tốt mà không bị va chạm
2. **Di chuyển**: Di chuyển chuột để xoay hướng, giữ chuột trái để bay
3. **Tấn công**: Nhấn `W` để bắn đạn
4. **Chiến thuật**: Sử dụng movement để né tránh thiên thạch trong khi tấn công

## 📝 Ghi chú

- Đây là dự án midterm cho môn Game Development
- Game sử dụng physics 2D của Unity với Rigidbody2D
- Tất cả assets và code được tổ chức theo chuẩn Unity best practices

## 👨‍💻 Tác giả

**it2kvku** - [GitHub Profile](https://github.com/it2kvku)

## 📄 License

Dự án này được phát triển cho mục đích học tập.

---

*Phát triển với ❤️ sử dụng Unity*
