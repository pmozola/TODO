import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { TaskService } from 'src/app/services/task.service';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-add-task-dialog',
  templateUrl: './add-task-dialog.component.html',
  styleUrls: ['./add-task-dialog.component.css']
})
export class AddTaskDialogComponent implements OnInit {
  taskForm: FormGroup;
  constructor(private formBuilder: FormBuilder,
    private taskService: TaskService,
    public dialogRef: MatDialogRef<AddTaskDialogComponent>) { }

  ngOnInit() {
    this.taskForm = this.formBuilder.group({
      title: ['', Validators.required],
      description: ['']
    })
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    if (this.taskForm.valid) {
      this.taskService
        .add(this.taskForm.value)
        .subscribe(_ => this.dialogRef.close(true));
    }
  }
}
