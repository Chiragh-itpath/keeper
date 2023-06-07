<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

class Keep extends Model
{
    use HasFactory;
    
    use SoftDeletes;

    protected $fillable = [
        'id',
        'title',
        'created_by',
        'updated_by',
        'tag_id',
        'project_id',
    ];

    protected $dates = [
        'created_at',
        'updated_at',
        'deleted_at',
    ];
    public function tag()
    {
        return $this->belongsTo(Tag::class);
    }

    public function project()
    {
        return $this->belongsTo(Project::class);
    }

    public function users()
    {
        return $this->belongsToMany(User::class);
    }
}
