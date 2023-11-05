express = require("express");
const app = express();
const port = 8000;

const students = Array(100)
  .fill(0)
  .map((_, index) => ({
    id: index,
    name: `Student${index}`,
    dob: Date.now(),
    grades: [2.3, 4, 5, 4.4],
    subjects: [
      {
        name: "PIZ",
        ects: 11,
      },
      {
        name: "DIS",
        ects: 10,
      },
    ],
  }));

app.get("/students", (req, res) => {
  res.send(students);
});

app.get("/students/:studentId", (req, res) => {
  const student = students.find(
    (student) => student.id == req.params.studentId
  );

  console.log(req.params.studentId);
  if (!student) {
    res.sendStatus(404);
    return;
  }

  res.send(student);
});

app.post("/students/:studentName", (req, res) => {
    
});

app.listen(port, () => {
  console.log(`Example app listening on port ${port}`);
});