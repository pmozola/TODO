import { Component, OnInit, Input } from '@angular/core';
import { ITask } from 'src/app/models/task.view-model';

@Component({
  selector: 'app-task-card',
  templateUrl: './task-card.component.html',
  styleUrls: ['./task-card.component.css']
})
export class TaskCardComponent implements OnInit {
  @Input() task: ITask;
  constructor() { }

  ngOnInit() {
  }

}
