# Mission Demolition

### 2023.12.20报告
1. 实现了用户的鼠标输入，如事件函数OnMouseEnter、OnMouseExit、OnMouseDown，和Input类函数Input.GetMouseButtonUp()和Input类字段Input.mousePosition
2. 实现了弹弓拉弓和发射弹珠的效果，学习了向量相关的知识，如计算向量的加减和大小。
3. 使用了Lerp()函数，利用线性插值去处理平滑的相机运动
4. 使用了相机的orthographicSize去控制相机视野的平滑缩放
5. 对Rigidbody的更深入的了解，比如isKinematic（会无视物理影响），和使用constrains去限制弹珠的滚动
6. 创建了物理材质，调整了材质的弹性，并应用在了Rigidbody上
7. 借助相机去获取鼠标在游戏窗口的世界坐标