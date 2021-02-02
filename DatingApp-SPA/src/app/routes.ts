import {Routes} from '@angular/router';
import { HomeComponent} from './home/home.component';
import { ListsComponent } from './lists/lists.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemeberDetailComponent } from './members/memeber-detail/memeber-detail.component';
import { MessagesComponent } from './messages/messages.component';
import { AuthGuard } from './_guards/auth.guard';
import { MemberDetailResolver } from './_resolvers/member-detail.resolver';
import { MemeberListResolver } from './_resolvers/member-list.resolver';

export const appRoutes: Routes = [
    {path : '', component : HomeComponent},

    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path : 'members' , component : MemberListComponent , resolve: {users: MemeberListResolver}},
            {path : 'members/:id' , component : MemeberDetailComponent , resolve: {user : MemberDetailResolver}},
            { path : 'lists' , component : ListsComponent},
            { path : 'messages' , component : MessagesComponent},
        ]
    },
    { path : '**' , redirectTo: '' , pathMatch : 'full'}
];
