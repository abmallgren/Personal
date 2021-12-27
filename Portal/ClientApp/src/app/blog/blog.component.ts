import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-blog',
    templateUrl: './blog.component.html'
})
export class BlogComponent {
    public blogPosts: BlogPost[];

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        http.get<BlogPost[]>(baseUrl + 'api/blog').subscribe(result => {
            this.blogPosts = result;
        }, error => console.error(error));
    }
}

interface BlogPost {
    blogPostID: number;
    title: string;
    content: string;
    postedOn: Date;
}