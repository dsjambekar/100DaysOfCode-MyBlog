export default function Page(props) {
	return (
		<div className="page">
			<span className="page-day">
				<span className="page-day-hashtag">#</span>
				Day{props.page.day}
			</span>
			<p className="page-title">{props.page.title}</p>
			<span className="page-date">{props.page.date}</span>
			<p className="page-body">{props.page.body}</p>
		</div>
	);
}
