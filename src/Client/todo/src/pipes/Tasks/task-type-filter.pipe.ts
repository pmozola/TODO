import { Pipe, PipeTransform } from '@angular/core';
import { Observable } from 'rxjs';
import { ITask } from 'src/app/models/task.view-model';
import { filter, map } from 'rxjs/operators';

@Pipe({
  name: 'taskTypeAsyncPipe'
})
export class TaskTypeAsyncPipe implements PipeTransform {

  transform(tasks: Observable<ITask[]>, taskId: number) {
    return tasks
      .pipe(
        map(tasks => tasks.filter(x => x.statusId === taskId))
      );
  }
}
