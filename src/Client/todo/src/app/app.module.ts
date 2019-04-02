import { NgModule, ErrorHandler } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MatButtonModule, MatCheckboxModule, MatDialogModule, MatCardModule, MatFormFieldModule, MatInputModule, MatRippleModule } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TodoComponent } from './pages/todo/todo.component';
import { AddTaskDialogComponent } from './pages/todo/add-task-dialog/add-task-dialog.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TaskTypeAsyncPipe } from 'src/pipes/Tasks/task-type-filter.pipe';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { ErrorsHandler } from './handlers/errors-handler';
import { ToastrModule } from 'ngx-toastr';
import { TaskCardComponent } from './pages/todo/task-card/task-card.component';

@NgModule({
  declarations: [
    AppComponent,
    AddTaskDialogComponent,
    TodoComponent,
    TaskTypeAsyncPipe,
    TaskCardComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCheckboxModule,
    MatDialogModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatCardModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatRippleModule,
    DragDropModule,
    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true
    })

  ],
  providers: [
    {
      provide: ErrorHandler,
      useClass: ErrorsHandler
    },
  ],
  entryComponents: [
    AddTaskDialogComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
